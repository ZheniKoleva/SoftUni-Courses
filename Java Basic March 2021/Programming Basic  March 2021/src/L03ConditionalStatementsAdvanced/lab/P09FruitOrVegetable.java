package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P09FruitOrVegetable {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String product = scanner.nextLine();

        boolean isFruit = product.equals("banana") || product.equals("apple")
                          || product.equals("kiwi") || product.equals("cherry")
                          || product.equals("lemon") || product.equals("grapes");
        boolean isVegetable = product.equals("tomato") || product.equals("cucumber")
                              || product.equals("pepper") || product.equals("carrot");

        if (isFruit) {
            System.out.println("fruit");
        }else if (isVegetable) {
            System.out.println("vegetable");
        }else {
            System.out.println("unknown");
        }
    }
}
