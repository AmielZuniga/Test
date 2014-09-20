#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>


#define  MAXLINE 255

int
main(void)
{
    char    buf[MAXLINE];
    pid_t    pid;
    int        status;
    // Change
    printf("%% ");
    fgets(buf, MAXLINE, stdin);
    if (buf[strlen(buf) - 1] == '\n')
        buf[strlen(buf) - 1] = 0;
    execlp("sh", "sh", "-c", buf, (char *)0);
    printf("couldn't execute: %s", buf);
    exit(127);
}
