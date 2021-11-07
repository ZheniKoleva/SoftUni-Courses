package L04ForLoop.lab;

import java.util.Scanner;

public class P06VowelsSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();

        int sumVowel = 0;

        for (int i = 0; i < text.length() ; i++) {
            switch (text.charAt(i)) {
                case 'a':
                    sumVowel += 1;
                    break;
                case 'e':
                    sumVowel += 2;
                    break;
                case 'i':
                    sumVowel += 3;
                    break;
                case 'o':
                    sumVowel += 4;
                    break;
                case 'u':
                    sumVowel += 5;
                    break;
            }
        }
        System.out.printf("%d", sumVowel);
    }
}
