from datetime import date, timedelta


class Funcionario:
    def __init__(self, nome, data_nascimento, salario):
        self._nome: str = nome
        self._data_nascimento: str = data_nascimento
        self._salario: float = salario

    @property
    def nome(self):
        return self._nome

    @property
    def salario(self):
        return self._salario

    def idade(self):
        data_nascimento_quebrada: [str] = self._data_nascimento.split('/')
        ano_nascimento: str = data_nascimento_quebrada[-1]
        ano_atual = date.today().year
        return ano_atual - int(ano_nascimento)

    def sobrenome(self):
        nome_completo: str = self._nome.strip()
        nome_quebrado: [str] = nome_completo.split(' ')
        return nome_quebrado[-1]

    def _eh_socio(self):
        sobrenomes_diretores: [str] = ['Silva', 'Windsor', 'Bourbon', 'Yamato', 'Al Saud', 'Khan', 'Tudor', 'Ptolomeu']
        return self._salario >= 100000 and (self.sobrenome() in sobrenomes_diretores)

    def decrescimo_salario(self):
        if self._eh_socio():
            self._salario = self._salario * 0.9

    def calcular_bonus(self):
        valor = self._salario * 0.1
        if valor > 1000:
            raise Exception('O salário é muito alto para receber um bônus')
        return valor

    def __str__(self):
        return f'Funcionario({self._nome}, {self._data_nascimento}, {self._salario})'
