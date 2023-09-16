from rest_framework import serializers

from escola.models import Aluno, Curso, Matricula


class AlunoSerializer(serializers.ModelSerializer):
    class Meta:
        model: Aluno = Aluno
        fields: tuple[str, str, str, str, str] = ('id', 'nome', 'rg', 'cpf', 'data_nascimento')


class CursoSerializer(serializers.ModelSerializer):
    class Meta:
        model: Curso = Curso
        fields: str = '__all__'  # retorna todas as informações de um curso


class MatriculaSerializer(serializers.ModelSerializer):
    class Meta:
        model: Matricula = Matricula
        fields: str = '__all__'


class ListaMatriculaAlunoSerializer(serializers.ModelSerializer):
    curso = serializers.ReadOnlyField(
        source='curso.descricao')  # Atribui a descrição do curso para a variável curso e retorna a descrição na requisição -> assim não é mostrado só a pk do curso
    periodo = serializers.SerializerMethodField()  # faz o retorno do campo periodo da classe curso por um método

    class Meta:
        model: Matricula = Matricula
        fields: str = ['curso', 'periodo']

    def get_periodo(
            self, obj):
        return obj.get_periodo_display()  # Retorna o periodo da mesma forma que é exibido no Django Admin


class ListaAlunosMatriculadosSerializer(serializers.ModelSerializer):
    aluno_nome = serializers.ReadOnlyField(source='aluno.nome')

    class Meta:
        model: Matricula = Matricula
        fields: str = ['aluno_nome']
