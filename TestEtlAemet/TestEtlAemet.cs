using EtlAemet;

class Program
{
    static void Main(string[] args)
    {
        MqttPublisher pub = new MqttPublisher();
        pub.Execute();
    }
}
