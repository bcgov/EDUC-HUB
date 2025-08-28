# Custom s2i builder image for CASInterfaceService
FROM registry.redhat.io/dotnet/dotnet-21-rhel7:latest

USER root

# Update system CA certificates
RUN yum update -y ca-certificates && update-ca-trust extract

USER 1001

# s2i scripts are inherited from the base image.
