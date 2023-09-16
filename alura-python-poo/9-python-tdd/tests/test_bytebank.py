import pytest
from pytest import mark
from bytebank import Funcionario


class TestClass:
    def test_quando_idade_recebe_13_03_2000_deve_retornar_23(self):
        entrada: str = '13/03/2000'  # Given-Contexto
        esperado: int = 23
        funcionario_teste: Funcionario = Funcionario('Teste', entrada, 1111)
        resultado: int = funcionario_teste.idade()  # When-Ação
        assert resultado == esperado  # Then-Desfecho

    def test_quando_sobrenome_recebe_lucas_carvalho_deve_retornar_carvalho(self):
        entrada: str = ' Lucas Carvalho '
        esperado: str = 'Carvalho'
        funcionario_teste: Funcionario = Funcionario(entrada, '13/03/2000', 1111)
        resultado: str = funcionario_teste.sobrenome()
        assert resultado == esperado

    def test_quando_decrescimo_salario_recebe_100000_deve_retornar_90000(self):
        entrada_salario: float = 100000
        entrada_nome: str = 'Gentil Silva'
        esperado: float = 90000
        funcionario_teste: Funcionario = Funcionario(entrada_nome, '09/08/1993', entrada_salario)
        funcionario_teste.decrescimo_salario()
        resultado: float = funcionario_teste.salario
        assert resultado == esperado

    @mark.calcular_bonus
    def test_quando_calcular_bonus_recebe_1000_deve_retornar_100(self):
        entrada: float = 1000
        esperado: float = 100
        funcionario_teste: Funcionario = Funcionario('Teste', '11/11/2000', entrada)
        resultado: float = funcionario_teste.calcular_bonus()
        assert resultado == esperado

    @mark.calcular_bonus
    def test_quando_calcular_bonus_recebe_100000_deve_retornar_exception(self):
        with pytest.raises(Exception):
            entrada: float = 100000
            funcionario_teste: Funcionario = Funcionario('Teste', '11/11/2000', entrada)
            resultado: float = funcionario_teste.calcular_bonus()
            assert resultado
