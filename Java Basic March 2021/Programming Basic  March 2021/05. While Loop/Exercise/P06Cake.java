package L05WhileLoop.exercise;

import java.util.Scanner;

public class P06Cake {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int width = Integer.parseInt(scanner.nextLine());
        int length = Integer.parseInt(scanner.nextLine());

        int cakePieces = width * length;
        boolean isEaten = false;

        String command = scanner.nextLine();
        while (!command.equals("STOP")) {
            cakePieces -= Integer.parseInt(command);

            if (cakePieces <= 0) {
                isEaten = true;
                break;
            }

            command = scanner.nextLine();
        }

        if (isEaten) {
            System.out.printf("No more cake left! You need %d pieces more.", Math.abs(cakePieces));

        } else {
            System.out.printf("%d pieces are left.", cakePieces);
        }
    }
}
