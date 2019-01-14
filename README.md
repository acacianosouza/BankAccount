# BankAccount

Collection do postman para teste:
https://www.getpostman.com/collections/fb4d10863906376260e1

* .Net Core 2.1
* FluentValidation
* Entity Framework Core
* DDD
* OAuth2
* SQL Server

Usuários para teste:

|Nome| Email  | Senha |
|-| ------------- | ------------- |
|William| wrodrigues.cv@gmail.com  | teste123  |
|José da Silva| william@verumit.com.br  | teste123  |

URL para autenticação local (oAuth2): http://localhost:5000/token

Respostas:

1. Acredito que utilizar DDD organiza muito o desenvolvimento do software. Os padrões estabelecidos pelo DDD fazem com que a comunicação entre a equipe técnica e a área de negócios seja mais fluída. Além disso o DDD é utilizado para tratar cenários mais complexos, pois em sua arquitetura as responsabilidades são dividias em blocos menores, o que auxilia na manutenabilidade e nos testes.

2. Uma arquitetura baseada em microserviços é definida por separar os módulos do sistema em pequenos serviços. Todos estes independentes e com sua prórpria estrutura/arquitetura, podendo até serem construídos em tecnologias diferentes. A grande vantagem de uma arquitetura como essa é a escalabilidade, pois pode-se escalar apenas os serviços mais utilizados e assim gerar uma alta disponibilidade economia de infraestrutura. Geralmente um serviço não consome o outro, de modo que a comunicação entre eles deve ser realizada através de mensageria e eventos.

3. A diferença entre comunicação síncrona e comunicação assíncrona é que a primeira é utilizada para execuções onde o resultado é esperado de forma urgente. Já a segunda é utilizada para comunicações que podem ser respondidas tempos após a execução e enquanto esse retorno não é recebido, o processo pode executar outras tarefas.
