FROM mcr.microsoft.com/mssql/server:2019-latest

ENV SA_PASSWORD password
ENV ACCEPT_EULA Y
ENV MSSQL_AGENT_ENABLED true
ENV MSSQL_PID Express

EXPOSE 1433