package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P03AnimalType {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String animal = scanner.nextLine();
        String output = null;

        switch (animal) {
            case "dog":
                output = "mammal";
                break;
            case "crocodile":
            case "tortoise":
            case "snake":
                output = "reptile";
                break;
            default:
                output = "unknown";
                break;
        }
        System.out.println(output);
    }
}
