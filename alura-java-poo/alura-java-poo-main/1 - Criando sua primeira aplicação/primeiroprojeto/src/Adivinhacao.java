import java.util.Random;
import java.util.Scanner;

public class Adivinhacao {
    public static void main(String[] args) {
        int random = new Random().nextInt(100);
        Scanner leia = new Scanner(System.in);
        int tentativas = 1;
        int escolhaUsuario = 0;

        System.out.println("Bem vindo ao jogo de adivinhação.");
        System.out.println("Você terá 5 oportunidades de acertar o número.");
        while (tentativas <= 5) {
            System.out.print("Digite o um número: ");
            escolhaUsuario = leia.nextInt();
            if(escolhaUsuario == random) {
                System.out.println("Parabéns você acertou.");
                break;
            } else if(escolhaUsuario > random) {
                System.out.println("O número digitado é maior que o número mágico.");
            } else {
                System.out.println("O número digitado é menor que o número mágico.");
            }
            tentativas++;
        }
        if(escolhaUsuario != random) {
            System.out.println("Que pena, você não conseguiu. O número mágico era: " + random);
        }
    }
}
