package L05WhileLoop.exercise;

import java.util.Scanner;

public class P01OldBooks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String searchedBook = scanner.nextLine();

        int booksCounter = 0;
        boolean isFound = false;
        String booksChecked = scanner.nextLine();

        while (!booksChecked.equals("No More Books")) {
            if (booksChecked.equals(searchedBook)) {
                isFound = true;
                break;
            }
            booksCounter++;

            booksChecked = scanner.nextLine();
        }

        if (isFound) {
            System.out.printf("You checked %d books and found it.", booksCounter);

        } else {
            System.out.printf("The book you search is not here!\n"
                    + "You checked %d books.", booksCounter);
        }
    }
}
