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

### Resources:
- https://medium.com/simform-engineering/creating-microservices-with-net-core-and-kafka-a-step-by-step-approach-1737410ba76a
- https://code-maze.com/aspnetcore-using-kafka-in-a-web-api/