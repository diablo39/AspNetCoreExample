#!/bin/bash

set -o errexit

SC_CONTRACT_DOCKER_VERSION="${SC_CONTRACT_DOCKER_VERSION:-2.0.1.BUILD-SNAPSHOT}"
APP_IP="$( ./whats_my_ip.sh )"
APP_PORT="${APP_PORT:-5000}"
ARTIFACTORY_PORT="${ARTIFACTORY_PORT:-8081}"
APPLICATION_BASE_URL="http://${APP_IP}:${APP_PORT}"
ARTIFACTORY_URL="http://${APP_IP}:${ARTIFACTORY_PORT}/artifactory/libs-release-local"
CURRENT_DIR="$( pwd )"
PROJECT_NAME="${PROJECT_NAME:-customer-service}"
PROJECT_GROUP="${PROJECT_GROUP:-com.example}"
PROJECT_VERSION="${PROJECT_VERSION:-0.0.1.RELEASE}"

# Option for API COMPATIBILITY CHECK
EXTERNAL_CONTRACTS_ARTIFACT_ID="${EXTERNAL_CONTRACTS_ARTIFACT_ID:-}"
EXTERNAL_CONTRACTS_GROUP_ID="${EXTERNAL_CONTRACTS_GROUP_ID:-}"
EXTERNAL_CONTRACTS_PATH="${EXTERNAL_CONTRACTS_PATH:-/}"
EXTERNAL_CONTRACTS_CLASSIFIER="${EXTERNAL_CONTRACTS_CLASSIFIER:-stubs}"
EXTERNAL_CONTRACTS_VERSION="${EXTERNAL_CONTRACTS_VERSION:-}"

echo "Sc Contract Version [${SC_CONTRACT_DOCKER_VERSION}]"
echo "Application URL [${APPLICATION_BASE_URL}]"
echo "Artifactory URL [${ARTIFACTORY_URL}]"
echo "Project Version [${PROJECT_VERSION}]"
echo "External contracts artifact id [${EXTERNAL_CONTRACTS_ARTIFACT_ID}]"
echo "External contracts group id [${EXTERNAL_CONTRACTS_GROUP_ID}]"
echo "External contracts path [${EXTERNAL_CONTRACTS_PATH}]"
echo "External contracts classifier [${EXTERNAL_CONTRACTS_CLASSIFIER}]"
echo "External contracts version [${EXTERNAL_CONTRACTS_VERSION}]"

mkdir -p build/spring-cloud-contract/output
docker run  --rm -e "APPLICATION_BASE_URL=${APPLICATION_BASE_URL}" -e "PUBLISH_ARTIFACTS=true" -e "PROJECT_NAME=${PROJECT_NAME}" -e "PROJECT_GROUP=${PROJECT_GROUP}" -e "REPO_WITH_BINARIES_URL=${ARTIFACTORY_URL}" -e "PROJECT_VERSION=${PROJECT_VERSION}" -e "EXTERNAL_CONTRACTS_ARTIFACT_ID=${EXTERNAL_CONTRACTS_ARTIFACT_ID}" -e "EXTERNAL_CONTRACTS_GROUP_ID=${EXTERNAL_CONTRACTS_GROUP_ID}" -e "EXTERNAL_CONTRACTS_CLASSIFIER=${EXTERNAL_CONTRACTS_CLASSIFIER}" -e "EXTERNAL_CONTRACTS_VERSION=${EXTERNAL_CONTRACTS_VERSION}" -v "${CURRENT_DIR}/contracts/:/contracts:ro" -v "${CURRENT_DIR}/build/spring-cloud-contract/output:/spring-cloud-contract-output/" springcloud/spring-cloud-contract:"${SC_CONTRACT_DOCKER_VERSION}"

docker run --rm -v "${CURRENT_DIR}/build/spring-cloud-contract/output:/spring-cloud-contract-output/" springcloud/spring-cloud-contract:"${SC_CONTRACT_DOCKER_VERSION}" chown -R $(id -u):$(id -g) "/spring-cloud-contract-output/"
