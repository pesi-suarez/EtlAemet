This project gathers data from the Spanish Meteorological Agency (AEMET) weather stations for a certain location and publishes it to a MQTT broker.

It consists of a class library, a unit test project for testing the library's classes and a console application.

In the class library there are two important classes, Etl and MqttPublisher.
 - Etl gets the relevant data from the AEMET API. There you must specify your API key, which can be obtained from the AEMET website. 
 - You may also specify the coordinates of your area of choice. It is now configured to be the island of Tenerife, below 100 meters of altitude.
 - MqttPublisher publishes this data to a broker and topic of your choice. It can be consumed by any client subscribed to the topic thereafter.

All of this was part of a bigger project that aimed to gather all kinds of real time data about coastal conditions in Tenerife. This part dealt  with the weather station data. 
Hope you can find it useful!
