using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Networking.Proximity;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using NFCLogistikaMobile.NfcCommon;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NFCLogistikaMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NfcReaderPage : Page
    {
        private List<NdefRecord> _recordList;
        private long _subscriptionId;
        private ProximityDevice device;
        private string _logText;


        public NfcReaderPage()
        {
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;

            _recordList = new List<NdefRecord>();
            device = ProximityDevice.GetDefault();
            if (device != null)
            {
                device.DeviceArrived += DeviceArrived;
                device.DeviceDeparted += DeviceDeparted;
            }
            SubscribeForMessage();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        /// <summary>
        /// Gets called when a detected NFC device is disconnected after arrival.
        /// </summary>
        /// <param name="sender">ProximityDevice instance</param>
        private void DeviceDeparted(ProximityDevice sender)
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                _logText = _logText + "\nLost at " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\n";
                AppText.Text = _logText + AppText.Text;
            });
        }

        /// <summary>
        /// Gets called when a NFC device is detected.
        /// </summary>
        /// <param name="sender">ProximityDevice instance</param>
        private void DeviceArrived(ProximityDevice sender)
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                _logText = "\nDetected at " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            });
        }
        private void MessageReceived(ProximityDevice sender, ProximityMessage message)
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (device != null)
                {
                    device.StopSubscribingForMessage(_subscriptionId);
                }

                var ndefRead = ParseNdef(message);
                _logText = _logText + ndefRead;
                ScrollViewer.UpdateLayout();
                ScrollViewer.ScrollToVerticalOffset(0);
                SubscribeForMessage();

                if (!Frame.Navigate(typeof(NfcTagDetailsPage), ndefRead))
                {
                    throw new Exception("Ooops.");
                }
            });
        }

        /// <summary>
        /// Parses the details from the given message. The output is a string
        /// that can be appended into the log.
        /// </summary>
        /// <param name="message">The message to parse.</param>
        /// <returns>The parsed details as a string.</returns>
        private string ParseNdef(ProximityMessage message)
        {
            var output = "";

            using (var buf = DataReader.FromBuffer(message.Data))
            {
                NdefRecordUtility.ReadNdefRecord(buf, _recordList);

                for (int i = 0, recordNumber = 0, spRecordNumber = 0; i < _recordList.Count; i++)
                {
                    NdefRecord record = _recordList.ElementAt(i);

                    if (!record.IsSpRecord)
                    {
                        if (System.Text.Encoding.UTF8.GetString(record.Type, 0, record.TypeLength) == "Sp")
                        {
                            output = output + "\n --End of Record No." + recordNumber; spRecordNumber = 0;
                            continue;
                        }
                        else
                        {
                            recordNumber++;
                            output = output + "\n --Record No." + recordNumber;
                        }
                    }
                    else
                    {
                        if (spRecordNumber == 0)
                        {
                            recordNumber++;
                            output = output + "\n --Record No." + recordNumber;
                        }

                        spRecordNumber++;
                        output = output + "\n Sp sub-record No." + spRecordNumber;
                    }

                    output = output + "\n MB:" + ((record.Mb) ? "1;" : "0;");
                    output = output + " ME:" + ((record.Me) ? "1;" : "0;");
                    output = output + " CF:" + ((record.Cf) ? "1;" : "0;");
                    output = output + " SR:" + ((record.Sr) ? "1;" : "0;");
                    output = output + " IL:" + ((record.Il) ? "1;" : "0;");

                    string typeName = NdefRecordUtility.GetTypeNameFormat(record);

                    if (record.TypeLength > 0)
                    {
                        output = output + "\n Type: " + typeName + ":"
                            + System.Text.Encoding.UTF8.GetString(record.Type, 0, record.TypeLength);
                    }

                    if ((record.Il) && (record.IdLength > 0))
                    {
                        output = output + "\n Id:"
                            + System.Text.Encoding.UTF8.GetString(record.Id, 0, record.IdLength);
                    }

                    if ((record.PayloadLength > 0) && (record.Payload != null))
                    {
                        if ((record.Tnf == 0x01)
                            && (System.Text.Encoding.UTF8.GetString(record.Type, 0, record.TypeLength) == "U"))
                        {
                            NdefUriRtd uri = new NdefUriRtd();
                            NdefRecordUtility.ReadUriRtd(record, uri);
                            output = output + "\n Uri: " + uri.GetFullUri();
                        }
                        else if ((record.Tnf == 0x01)
                            && (System.Text.Encoding.UTF8.GetString(record.Type, 0, record.TypeLength) == "T"))
                        {
                            NdefTextRtd text = new NdefTextRtd();
                            NdefRecordUtility.ReadTextRtd(record, text);
                            output = output + "\n Language: " + text.Language;
                            output = output + "\n Encoding: " + text.Encoding;
                            output = output + "\n Text: " + text.Text;
                        }
                        else
                        {
                            if (record.Tnf == 0x01)
                            {
                                output = output + "\n Payload:"
                                    + System.Text.Encoding.UTF8.GetString(record.Payload, 0, record.Payload.Length);
                            }
                        }
                    }

                    if (!record.IsSpRecord)
                    {
                        output = output + "\n --End of Record No." + recordNumber;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Subscribes for NDEF messages. This ensures that we get notified
        /// about the NFC events.
        /// </summary>
        private void SubscribeForMessage()
        {
            if (device != null)
            {
                _recordList.Clear();
                _subscriptionId = device.SubscribeForMessage("NDEF", MessageReceived);
            }
        }
    }
}
