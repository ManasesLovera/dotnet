# Learning Kafka

## Project structure

```
Kafka/
│── docker-compose.yml
│── README.md
├── ProducerService/
│   ├── ProducerService.sln
│   ├── Dockerfile
│   ├── appsettings.json
│   ├── Program.cs
│   ├── Controllers/
│   │   ├── KafkaProducerController.cs
│   ├── Services/
│   │   ├── KafkaProducerService.cs
|   ├── Interfaces/
│   │   ├── IKafkaProducerService.cs
│   ├── ProducerService.csproj
│
├── ConsumerService/
│   ├── ConsumerService.sln
│   │   ├── Dockerfile
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   │   ├── Interfaces/
│   │   │   ├── IKafkaConsumerService.cs
│   │   ├── Services/
│   │   │   ├── KafkaConsumerService.cs
│   ├── ConsumerService.csproj
```

### Resources:
- https://medium.com/simform-engineering/creating-microservices-with-net-core-and-kafka-a-step-by-step-approach-1737410ba76a
- https://code-maze.com/aspnetcore-using-kafka-in-a-web-api/
