#!/bin/sh

set -e

AWS_ACCOUNT_ID="$(aws sts get-caller-identity | jq -r .Account)"
AWS_DEFAULT_REGION="${AWS_DEFAULT_REGION:-eu-central-1}"
DOCKER_COMPOSE_PATH=/usr/local/lib/server/compose.yaml

# /usr/local/server/backup.sh

aws ecr get-login-password --region $AWS_DEFAULT_REGION | docker login --username AWS --password-stdin $AWS_ACCOUNT_ID.dkr.ecr.$AWS_DEFAULT_REGION.amazonaws.com
docker compose -f $DOCKER_COMPOSE_PATH pull
docker compose -f $DOCKER_COMPOSE_PATH up -d