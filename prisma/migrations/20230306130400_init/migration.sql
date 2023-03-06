-- CreateTable
CREATE TABLE "Timing" (
    "id" SERIAL NOT NULL,
    "checkin" TIMESTAMP(3) NOT NULL,
    "checkout" TIMESTAMP(3) NOT NULL,
    "isWorking" BOOLEAN NOT NULL,
    "TodaysEarnings" INTEGER NOT NULL,
    "TodaysHours" DECIMAL(65,30) NOT NULL,
    "TotalEarnings" INTEGER NOT NULL,
    "TotalHours" DECIMAL(65,30) NOT NULL,

    CONSTRAINT "Timing_pkey" PRIMARY KEY ("id")
);
