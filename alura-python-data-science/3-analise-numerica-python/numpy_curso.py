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
plt.plot(datas, kaliningrad)

print(np.mean(moscow))
print(np.mean(kaliningrad))
