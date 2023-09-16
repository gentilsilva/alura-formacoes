from django.urls import path
from galeria.views import index

urlpatterns: list = [
    path('', index),
]