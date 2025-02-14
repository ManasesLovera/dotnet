# Learning Kafka

## Project structure

```
kafka-docker-compose/
│── docker-compose.yml
│── .env
│── README.md
│
├── producer-service/
│   ├── ProducerService.sln
│   ├── ProducerService/
│   │   ├── Dockerfile
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   │   ├── Startup.cs
│   │   ├── Controllers/
│   │   │   ├── KafkaProducerController.cs
│   │   ├── Services/
│   │   │   ├── KafkaProducerService.cs
│   │   ├── Models/
│   │   │   ├── MessageModel.cs
│   ├── ProducerService.csproj
│
├── consumer-service/
│   ├── ConsumerService.sln
│   ├── ConsumerService/
│   │   ├── Dockerfile
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   │   ├── Startup.cs
│   │   ├── Services/
│   │   │   ├── KafkaConsumerService.cs
│   ├── ConsumerService.csproj
│
└── kafka/
    ├── kafka-config/
    │   ├── server.properties
    ├── zookeeper-config/
    │   ├── zookeeper.properties
```