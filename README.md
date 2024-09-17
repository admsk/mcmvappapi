[![version](https://img.shields.io/badge/version-1.0.0-yellow.svg)](https://semver.org)


## Escopo, pré-requisitos e objetivo
Sorteio de Habitação. 
O objetivo é o desenvolvimento de uma solução que auxilie a empresa a definir por meio de sorteios as pessoas que receberão o benefício e conquistar o sonho da casa própria.

A lista de participantes será fornecida por uma API, portanto, a aplicação deverá considerar esta listagem.

O objetivo é encontrar 5 sortudos, dentre todos eles, 1 pessoa Idosa, 1 pessoa com deficiência (especial) e mais 3 pessoas caracterizados como "geral".

Abaixo as regras que serão aplicadas no sorteio.

**Regras de aceitação para o sorteio **


1. Renda entre R$ 1.045,00 a R$ 5.225,00.

1. CPF precisa ser valido.

1. Idade maior de 15 anos.


1. Regra especial para cota de IDOSO a pessoa precisa ter idade superior 60 anos.
1. Regra especial para cota de DEFICIENTE FÍSICO a pessoa precisa ter informado o número do CID.


# Tecnologias 
Para o desenvolvimento da solução foi utilizado ASP.NET CORE 8 e ASP.NET MVC 8 com React.

## Iniciando...
Para compilação da aplicação, primeiro é necessário realizar o clone do projeto ou baixa-lo para a sua máquina.
Siga as intruções abaixo:

Para clonar: 

Abra um terminal no seu computador
Navegue até um diretório da sua escolha
Digite o comando: 

git@gitlab.com:admsk/mcmvappapi.git

Depois de clonado ou baixado navegue até a pasta criada

Digite  o comando: 

cd [pasta criada]

Digite o comando para abrir o VSCode para visualizar o projeto e os seus arquivos

code .



## Pré-requisitos
É necessário que o .NET CORE 8 esteja instalado na sua máquina se não tiver, é necessário primeiro realizar esta ação para dar continudade ao processo de compilação dos projetos

![.NET Core](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)

## Compilar e executar os projetos - [VSCODE] 
Usar o VSCode

Depois de atender ao pré-requisitos, estamos prontos para continuar.

Dentro da pasta criada, execute os comandos 
abaixo para subir a api.

dotnet run --project mcmvc.api

Acesse http://localhost:5094/participantes/all para ver os registros sendo trazidos pela api.


Digite o comando abaixo para subir a aplicação.

dotnet run --project mcmv.web

Aguarde a aplicação ser carregada ou acesse 
https://localhost:44441/

NOTA: Aguarde a aplicação ser carregada, pode ser que demore alguns segundos entre a compilação e a renderização.

Logo abaixo, algumas evidencias poderão ser visualizadas.

## Executar testes unitarios - [VISUAL STUDIO] 
Usar o Visual Studio (Preferencialmente o 2022)

Abra o projeto com o visual studio
Navegue até a aba "Test" e clique em "Run All Tests"

Na Janela que aparecerá ao lado o resultado dos testes serão exibidos.

## Evidências


[API](https://gitlab.com/admsk/mcmvappapi/-/blob/master/mcmv.web/ClientApp/imagens%20/endpoin-api-all.png?ref_type=heads)


[APLICACAO](https://gitlab.com/admsk/mcmvappapi/-/blob/master/mcmv.web/ClientApp/imagens%20/Captura%20de%20tela%20de%202024-09-16%2009-12-13.png?ref_type=heads)


[TESTES](https://gitlab.com/admsk/mcmvappapi/-/blob/master/mcmv.web/ClientApp/imagens%20/EvidenciaTestes.png?ref_type=heads)