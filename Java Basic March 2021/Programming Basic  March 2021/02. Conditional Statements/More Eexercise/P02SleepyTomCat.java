package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P02SleepyTomCat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int daysOff = Integer.parseInt(scanner.nextLine());

        int goal = 30000;
        int playsDaysOff = 127;
        int playsWorkingDays = 63;
        int workingDays = 365 - daysOff;

        int playTotalTime = (playsDaysOff * daysOff) + (playsWorkingDays * workingDays);
        int difference = Math.abs(playTotalTime - goal);
        int hours = difference / 60;
        int minutes = difference % 60;

        if (playTotalTime < goal) {
            System.out.printf("Tom sleeps well\n%d hours and %d minutes less for play", hours, minutes);
        }else {
            System.out.printf("Tom will run away\n%d hours and %d minutes more for play", hours, minutes);
        }
    }
}
