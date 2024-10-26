#!/bin/bash

# Espera o SQL Server estar disponível
while ! nc -z db 1433; do
  echo "Aguardando o banco de dados estar disponível..."
  sleep 2
done

# Executa as migrations
dotnet ef database update
