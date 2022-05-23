package L02ConditionalStatements.Lab;

import java.util.Scanner;

public class P05PasswordGuess {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String password = scanner.nextLine();
        String isCorrect = password.equals("s3cr3t!P@ssw0rd") ? "Welcome" : "Wrong password!";
        System.out.println(isCorrect);
    }
}
