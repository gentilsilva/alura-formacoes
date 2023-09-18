import numpy as np
import matplotlib.pyplot as plt


# loadtxt carrega um arquivo de texto. loadtxt(arquivo, delimitador_de_dados, colunas_desejadas)
# Ele não lê arquivos só no sistema, posso carregar de uma url também.
dados = np.loadtxt(fname="apples_ts.csv", delimiter=",", usecols=np.arange(1, 88, 1))

# print(dados)

# Verifica a dimensão de dados
# print(dados.ndim)

# Verifica o tamnaho de dados
# print(dados.size)

# Verifica a quantidade de linhas e colunas de dados
# print(dados.shape)

# Cria uma matriz tramsposta => Transforma as linhas em colunas
dados_transposto = dados.T
# print(dados_transposto)

# Captura em um array de datas no dados_transposto
datas = dados_transposto[:,0]

# Trata as datas para serem capturadas como "meses", pois estavam sendo tratadas como número => 1,2013 e não 1.2013
datas = np.arange(1, 88, 1)

# Captura em um array os preços de todas as colunas
precos = dados_transposto[:,1:6]

# Plota a variação de preços em relação aos 87 meses
# plt.plot(datas, precos[:, 0])

# Atribuindo em cada cidade os valores de preços respectivos
moscow = precos[:, 0]
kaliningrad = precos[:, 1]
petersburg = precos[:, 2]
krasnodar = precos[:, 3]
ekaterinburg = precos[:, 4]

# Captura a variação de dados de ano em ano
moscor_ano_um = moscow[0:12] 
moscor_ano_dois = moscow[12:24]
moscor_ano_tres = moscow[24:36]
moscor_ano_quatro = moscow[36:48]

# Plota em um gráfico essa captura por ano
    # plt.plot(np.arange(1, 13, 1), moscor_ano_um)
    # plt.plot(np.arange(1, 13, 1), moscor_ano_dois)
    # plt.plot(np.arange(1, 13, 1), moscor_ano_tres)
    # plt.plot(np.arange(1, 13, 1), moscor_ano_quatro)

# Cria legenda para o gráfico
    # plt.legend(["Ano um", "Ano dois", "Ano três", "Ano quatro"])

# Compara se dois arrays são iguais
    # print(np.array_equal(moscor_ano_tres, moscor_ano_quatro))

# Verifica se a diferença entre os valores é de determinado valor no.allclose(array_um, array_dois, valor_verificador)
    # print(np.allclose(moscor_ano_tres, moscor_ano_quatro, 10))

# plt.plot(datas, kaliningrad)

# Verifica se existe valor to dipo NaN np.isnan(vetor)
    # print(sum(np.isnan(kaliningrad)))

# Para tratar um valor NaN, verificamos a media do valor antecessor + o sucessor
    # Verificar média sem usar np
        # media = (kaliningrad[3] + kaliningrad[5]) / 2

# Verificando média usando np
kaliningrad[4] = np.mean([kaliningrad[3], kaliningrad[5]])

# x = datas

# Equação da reta para verificar o crescimento
    # y = 2 * x + 80

# Diferença entre os arrays => calcular a norma
    # np.sqrt(np.sum(np.power((moscow - y), 2)))

# Calculando uma segunda reta
    # y = 0.52 * x + 80

# Resumir todos os calculos(de diferença) para conseguir calcular a norma entre dois arrays
    # np.linalg.norm(moscow - y)

# Calcular coeficiente angular
    # a = coeficiente angular, n = número de elementos, Y = moscow, X = datas
    # a = (n * Soma(Xi * Yi) - Soma(Xi) * Soma(Yi)) / n * Soma(Xi²) - (Soma(Xi))²


# O que será feito abaixo é o processo de regressão linear
X = datas
Y = moscow
n = np.size(moscow)
a = (n * np.sum(X * Y) - np.sum(X) * np.sum(Y)) / (n * np.sum(X**2) - np.sum(X)**2)

# Calcular coeficiente linear
    # b = coeficiente linear, a = coeficiente angular, media = media_dos_arrays
    # b = Media(Yi) - a * Media(Xi)

b = np.mean(Y) - a * np.mean(X)

# Calculo da norma
y = a * X + b
norma = np.linalg.norm(moscow - y)

plt.plot(datas, moscow)
plt.plot(X, y)

# Verificar um ponto na reta => nesse caso, 41.5
plt.plot(41.5, 41.5 * a + b, "*r")

# Verificação em um ponto futuro
plt.plot(100, 100 * a + b, "*r")
plt.show()