#!/bin/bash
set -e

# Update the trust store with any custom certs mounted at /etc/pki/ca-trust/source/anchors/
echo "Updating CA trust store..."
update-ca-trust extract

echo "Starting application..."
exec /usr/libexec/s2i/run

