package L01FirstStepInCoding.moreExercise;

import java.util.Scanner;

public class P09WeatherForecast {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String weather = scanner.nextLine();

        if (weather.equals("sunny")) {
            System.out.println("It's warm outside!");
        }else {
            System.out.println("It's cold outside!");
        }
    }
}
