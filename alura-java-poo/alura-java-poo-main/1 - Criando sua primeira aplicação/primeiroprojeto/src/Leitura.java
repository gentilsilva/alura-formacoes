import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Leitura {
    public static void main(String[] args) {
        Scanner leia = new Scanner(System.in);

        System.out.print("Digite seu filme favorito: ");
        String filme = leia.nextLine();
        System.out.print("Qual o ano de lançamento? ");
        int anoDeLancamento = leia.nextInt();
        System.out.print("Qual avaliação do filme: ");
        double avaliacao = leia.nextDouble();

        System.out.println(filme);
        System.out.println(anoDeLancamento);
        System.out.println(avaliacao);
    }
}
