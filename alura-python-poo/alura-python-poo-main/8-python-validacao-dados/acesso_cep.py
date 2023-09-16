import requests


class BuscaEndereco:
    def __init__(self, cep: str):
        cep: str = cep
        if self.cep_eh_valido(cep):
            self.cep = cep
        else:
            raise ValueError("Cep invalido")

    def __str__(self):
        return self.format_cep()

    def cep_eh_valido(self, cep: str):
        if len(cep) == 8:
            return True
        else:
            return False

    def format_cep(self):
        return "{}-{}".format(self.cep[:5], self.cep[5:])

    def acessa_via_cep(self):
        url: str = "https://viacep.com.br/ws/{}/json/".format(self.cep)
        resposta = requests.get(url)
        dados: dict = resposta.json()
        return [
            dados['bairro'],
            dados['localidade'],
            dados['uf']
        ]
