# Run Redis local with Docker

Run Redis local with help of docker, if you want to test the endpoint ​/Account​/redis

# Prerequisite 

Have Docker installed on your machine

# Installation

### Pull Redis down
docker pull redis

### Docker run Redis-container
docker run -d -p 6379:6379 --name redis-container -v c:/data:/data redis --appendonly yes