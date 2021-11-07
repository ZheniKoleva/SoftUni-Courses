package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P04PersonalTitles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double age = Double.parseDouble(scanner.nextLine());
        char gender = scanner.nextLine().charAt(0);
        String output = null;

        if (age < 16) {
            switch (gender) {
                case 'f':
                    output = "Miss";
                    break;
                case 'm':
                    output = "Master";
                    break;
            }
        }else {
            switch (gender) {
                case 'f':
                    output = "Ms.";
                    break;
                case 'm':
                    output = "Mr.";
                    break;
            }
        }

        System.out.println(output);
    }
}
