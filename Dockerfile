# Custom s2i builder image for CASInterfaceService
FROM registry.redhat.io/dotnet/dotnet-21-rhel7:latest

USER root

COPY entrypoint.sh /opt/app-root/entrypoint.sh
RUN chmod +x /opt/app-root/entrypoint.sh
ENTRYPOINT ["/opt/app-root/entrypoint.sh"]

USER 1001

# s2i scripts are inherited from the base image.
