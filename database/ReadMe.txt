Om de database te starten met docker moet je de volgende stappen volgen.


Windows:
1. Start de docker containers door het start.bat bestand te runnen.
2. Wacht tot de containers volledig zijn opgestart. ( Dit kun je controleren door naar http://localhost:8080/ te gaan en in te loggen met Username: "user" en Password: "root")
3. Vul de database door met je rechtermuisknop op insertdata.ps1 te klikken en dan op run with powershell te klikken.
4. De database is nu klaar voor gebruik.

Mac:
1. Open een Terminal in de dataCompose folder
2. Type: "docker-compose up -d"
3. Wacht tot de containers volledig zijn opgestart. ( Dit kun je controleren door naar http://localhost:8080/ te gaan en in te loggen met Username: "user" en Password: "root")
4. Type: "docker run --rm -v $PWD/flyway:/flyway/sql flyway/flyway \-url=jdbc:mysql://host.docker.internal:3306/busplanDB \-user=user -password=root \-locations=filesystem:/flyway/sql/migrations \migrate"
5. Wacht tot het vorige command volledig is afgerond
6. Type: "docker run --rm -v $PWD/flyway:/flyway/sql flyway/flyway \-url=jdbc:mysql://host.docker.internal:3306/busplanDB \-user=user -password=root \-locations=filesystem:/flyway/sql/testdata \migrate"
7. De database is nu klaar voor gebruik.
