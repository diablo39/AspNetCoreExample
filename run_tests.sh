#!/bin/bash

set -o errexit

echo -e "\n\nRunning tests against Artifactory\n\n"

# Start docker infra
./stop_infra.sh
./setup_infra.sh

# Kill & Run app
pkill -f "dotnet" && echo "Killed running dotnet app" || echo "Failed to kill app"
export ASPNETCORE_ENVIRONMENT="ContractTests"
export ASPNETCORE_SERVER_URLS="$( ./whats_my_ip.sh )"

pushd src/AspNetCoreExample
  nohup dotnet run &
popd

# Execute contract tests
./run_contract_tests.sh

# Kill app
pkill -f "dotnet" && echo "Killed running dotnet app"
