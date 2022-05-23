package L05WhileLoop.moreExercise;

import java.util.Scanner;

public class P03StreamOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String inputCharacter = scanner.nextLine();

        boolean hasC = false;
        boolean hasO = false;
        boolean hasN = false;
        StringBuilder currentWord = new StringBuilder();
        StringBuilder finalWord = new StringBuilder();

        while (!inputCharacter.equals("End")) {

            char currentChar = inputCharacter.charAt(0);
            switch (currentChar) {
                case 'c':
                    if (hasC) {
                        currentWord.append(currentChar);
                    }else {
                        hasC = true;
                    }
                    break;

                case 'o':
                    if (hasO) {
                        currentWord.append(currentChar);
                    }else {
                        hasO = true;
                    }
                    break;

                case 'n':
                    if (hasN) {
                        currentWord.append(currentChar);
                    }else {
                        hasN = true;
                    }
                    break;

                default:
                    if (currentChar < 65 || currentChar > 122 || (currentChar > 91 && currentChar < 97)) {
                        inputCharacter = scanner.nextLine();
                        continue;
                    }else {
                        currentWord.append(currentChar);
                    }
                    break;
            }

            if (hasC && hasN && hasO) {
                currentWord.append(" ");
                finalWord.append(currentWord);
                currentWord = new StringBuilder();
                hasC = false;
                hasN = false;
                hasO = false;
            }
            inputCharacter = scanner.nextLine();
        }
        System.out.println(finalWord);
    }
}
