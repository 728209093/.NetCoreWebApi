FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
RUN echo 'Asia/Shanghai' >/etc/timezone
RUN mkdir /HelloWorldWebApplication
COPY ./ /HelloWorldWebApplication
EXPOSE 80
WORKDIR /HelloWorldWebApplication
CMD ["/bin/bash","-c","./HelloWorldWebApplication"]
