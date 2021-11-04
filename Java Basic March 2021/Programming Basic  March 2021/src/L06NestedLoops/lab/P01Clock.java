package L06NestedLoops.lab;

public class P01Clock {
    public static void main(String[] args) {
        for (int hour = 0; hour < 24; hour++) {
            for (int minutes = 0; minutes < 60; minutes++) {
                System.out.printf("%d:%d%n", hour, minutes);
            }
        }
    }
}
