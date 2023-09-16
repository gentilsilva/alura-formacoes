from datetime import datetime, timedelta


class DatasBr:
    def __init__(self):
        self.momento_cadastro: datetime = datetime.today()

    def __str__(self):
        return self.format_data()

    def mes_cadastro(self):
        meses_do_ano: list = [
            "janeiro", "fevereiro", "março",
            "abril", "maio", "junho", "julho",
            "agosto", "setembro", "outubro",
            "novembro", "dezembro"
        ]
        mes_cadastro: int = self.momento_cadastro.month - 1
        return meses_do_ano[mes_cadastro]

    def dia_semana(self):
        dia: int = self.momento_cadastro.weekday()
        dia_semana = [
            "segunda-feira", "terça-feira", "quarta-feira",
            "quinta-feira", "sexta-feira", "sábado", "domingo"
        ]
        return dia_semana[dia]

    def format_data(self):
        data_formatada: str = self.momento_cadastro.strftime("%d/%m/%Y - %H:%M")
        return data_formatada

    def data_cadastro(self):
        data_cadastro: timedelta = datetime.today().__sub__(self.momento_cadastro)
        return data_cadastro
