import requests
from acesso_cep import BuscaEndereco
import random
'''
cep = "31620040"
objeto_cep = BuscaEndereco(cep)

#resposta: requests = requests.get("https://viacep.com.br/ws/01001000/json/"

json: dict[str, str, str]

json = objeto_cep.acessa_via_cep()
print(json)
'''


upper_case: str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
lower_case: str = "abcdefghijklmnopqrstuvwxyz"
numbers: str = "1234567890"
symbols: str = "!@#$%&*()"

all: str = upper_case + lower_case + numbers + symbols

length: int = 16
everthyng: str = "".join(random.sample(all, length))

print(everthyng)
