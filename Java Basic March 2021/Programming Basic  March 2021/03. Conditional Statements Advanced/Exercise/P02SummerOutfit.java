package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P02SummerOutfit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int degrees = Integer.parseInt(scanner.nextLine());
        String periodOfDay = scanner.nextLine().toLowerCase();

        String outfit = null;
        String shoes = null;
        String output = null;

        switch (periodOfDay) {
            case "morning":
                if (degrees >= 10 && degrees <= 18) {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }else if (degrees <= 24) {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }else {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }

                break;

            case "afternoon":
                if (degrees >= 10 && degrees <= 18) {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }else if (degrees <= 24) {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }else {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }

                break;
            case "evening":
                outfit = "Shirt";
                shoes = "Moccasins";
                break;
        }
        output = String.format("It's %d degrees, get your %s and %s.", degrees, outfit, shoes);
        System.out.println(output);
    }
}
