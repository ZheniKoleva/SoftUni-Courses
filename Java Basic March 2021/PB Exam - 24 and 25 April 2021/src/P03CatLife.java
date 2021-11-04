import java.util.Scanner;

public class P03CatLife {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String catBreed = scanner.nextLine();
        char catGender = scanner.nextLine().charAt(0);

        int yearsMaxLiving = 0;

        switch (catBreed) {

            case "British Shorthair":
                if (catGender == 'm') {
                    yearsMaxLiving = 13;
                }
                else {
                    yearsMaxLiving = 14;
                }
                break;

            case "Siamese":
                if (catGender == 'm') {
                    yearsMaxLiving = 15;
                }
                else {
                    yearsMaxLiving = 16;
                }
                break;

            case "Persian":
                if (catGender == 'm') {
                    yearsMaxLiving = 14;
                }
                else {
                    yearsMaxLiving = 15;
                }
                break;

            case "Ragdoll":
                if (catGender == 'm') {
                    yearsMaxLiving = 16;
                }
                else {
                    yearsMaxLiving = 17;
                }
                break;

            case "American Shorthair":
                if (catGender == 'm') {
                    yearsMaxLiving = 12;
                }
                else {
                    yearsMaxLiving = 13;
                }
                break;

            case "Siberian":
                if (catGender == 'm') {
                    yearsMaxLiving = 11;
                }
                else {
                    yearsMaxLiving = 12;
                }
                break;

            default:
                System.out.printf("%s is invalid cat!", catBreed);
                break;
        }

        if (yearsMaxLiving != 0) {
            int humanEqualsYears = yearsMaxLiving * 12;
            int catMonts = humanEqualsYears / 6;

            System.out.printf("%d cat months", catMonts);
        }

    }
}
