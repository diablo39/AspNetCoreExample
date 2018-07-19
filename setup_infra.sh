#!/bin/bash
echo "Building docker"
pushd docker
docker-compose build
docker-compose up -d
popd
