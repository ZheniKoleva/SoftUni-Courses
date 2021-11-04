package L05WhileLoop.lab;

import java.util.Scanner;

public class P02Password {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String userName = scanner.nextLine();
        String password = scanner.nextLine();

        String login = scanner.nextLine();
        while (!login.equals(password)) {
            login = scanner.nextLine();
        }

        System.out.printf("Welcome %s!", userName);
    }
}
