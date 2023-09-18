import numpy as np


# loadtxt carrega um arquivo de texto. loadtxt(arquivo, delimitador_de_dados, colunas_desejadas)
# Ele não lê arquivos só no sistema, posso carregar de uma url também.
dados = np.loadtxt(fname="apples_ts.csv", delimiter=",", usecols=np.arange(1, 88, 1))

# print(dados)
print(dados.ndim)
print(dados.size)
print(dados.shape)
dados_transposto = dados.T
print(dados_transposto)