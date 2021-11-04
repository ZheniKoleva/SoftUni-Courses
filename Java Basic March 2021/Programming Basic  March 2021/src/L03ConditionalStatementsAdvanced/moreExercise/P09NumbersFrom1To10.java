package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P09NumbersFrom1To10 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = 1;
        while (number <= 10) {
            System.out.println(number++);
        }
    }
}
