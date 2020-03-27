using EtlAemet.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace EtlAemet
{
    public class MqttPublisher
    {
        MqttClient client;

        public void Execute()
        {
            Etl etl = new Etl();
            List<StationData> data = etl.GetTenerifeCoastalData();

            string broker = "iot.eclipse.org";
            string topic = "your topic";

            client = new MqttClient(broker);
            client.MqttMsgPublished += new MqttClient.MqttMsgPublishedEventHandler(CloseConnection);
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            foreach (StationData stationData in data)
                client.Publish(topic, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(stationData, Formatting.None)), qosLevel: 2, retain : false);
        }

        //Program won't close if we don't handle the event. See https://github.com/eclipse/paho.mqtt.m2mqtt/issues/9
        public void CloseConnection(object sender, MqttMsgPublishedEventArgs e)
        {
            client.Disconnect();
        }

    }
}
