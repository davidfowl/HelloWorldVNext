# Builds the image to run the helloworldweb application
# inside a Docker container.
# 
# Instructions:
# 1. Run `docker build .` here.
# 2. Save the image id produced in the last step.
# 3. Start the container as daemon: `docker run -i -d -p 8080:8080 <imageid>`
# 4. Head over to http://ip:8080 (`ip` being wherever your docker service
#    is running)
#
FROM ahmetalpbalkan/aspnet-vnext:alpha
MAINTAINER Ahmet Balkan <ahmetalpbalkan at gmail.com>
EXPOSE 8080

RUN mkdir /app
ADD src /app/src
ADD NuGet.Config /app/NuGet.Config

WORKDIR /app/src
RUN kpm restore

WORKDIR helloworldweb
ENTRYPOINT k web
