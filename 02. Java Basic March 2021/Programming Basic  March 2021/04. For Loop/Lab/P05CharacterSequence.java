package L04ForLoop.lab;

import java.util.Scanner;

public class P05CharacterSequence {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();

        for (int i = 0; i < text.length(); i++) {
            System.out.printf("%s%n", text.charAt(i));
        }
    }
}
