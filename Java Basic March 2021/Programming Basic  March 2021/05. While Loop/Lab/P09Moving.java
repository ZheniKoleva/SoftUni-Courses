package L05WhileLoop.lab;

import java.util.Scanner;

public class P09Moving {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int width = Integer.parseInt(scanner.nextLine());
        int length = Integer.parseInt(scanner.nextLine());
        int height = Integer.parseInt(scanner.nextLine());

        int spaceTotal = width * length * height;
        boolean noFreeSpace = false;

        String command = scanner.nextLine();
        while (!command.equals("Done")) {
            spaceTotal -= Integer.parseInt(command);

            if (spaceTotal <= 0) {
                noFreeSpace = true;
                break;
            }

            command = scanner.nextLine();
        }

        if (noFreeSpace) {
            System.out.printf("No more free space! You need %d Cubic meters more.", Math.abs(spaceTotal));
        }else {
            System.out.printf("%d Cubic meters left.", spaceTotal);
        }
    }
}
