# Setur Case

### Getting Started

#### Executing program

- Create Kafka topic

```
docker compose exec broker \
  kafka-topics --create \
    --topic purchases \
    --bootstrap-server localhost:9092 \
    --replication-factor 1 \
    --partitions 1
```

\*Run docker compose

```
docker-compose  -f ./docker-compose.yml -f ./docker-compose.override.yml -d up
```
