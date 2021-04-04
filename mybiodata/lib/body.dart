import 'package:flutter/material.dart';

// Untuk Tubuh
// ignore: camel_case_types
class bodi extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    const ukuran = TextStyle(fontSize: 20);
    return ListView(
      padding: const EdgeInsets.all(32.0),
      children: <Widget>[
        Container(
            height: 400,
            width: 200,
            margin: EdgeInsets.all(20),
            child: Image.asset("images/sulailah.jpeg")),
        Text("Nama : Sulailah", style: ukuran),
        Text("Kelas : Informatika", style: ukuran),
        Text("TTL : sumenep 16 Maret 2001", style: ukuran),
        Text(
          "Hobi : membaca",
          style: ukuran,
        ),
        ElevatedButton(
            style: ElevatedButton.styleFrom(primary: Colors.blue),
            onPressed: () {
              showDialog(
                  context: context,
                  builder: (BuildContext context) => AlertDialog(
                        title: const Text("Judul Dialog"),
                        content: const Text("contoh peringatan"),
                        actions: <Widget>[
                          TextButton(
                              onPressed: () => Navigator.pop(context, "batal"),
                              child: const Text("Batal")),
                          TextButton(
                              onPressed: () => Navigator.pop(context, "ya"),
                              child: const Text("Ya")),
                        ],
                      )).then((returnVal) {
                if (returnVal != null) {
                  ScaffoldMessenger.of(context).showSnackBar(SnackBar(
                    content: Text("Kamu Klik $returnVal"),
                    action: SnackBarAction(
                      label: "Ya",
                      onPressed: () {},
                    ),
                  ));
                }
              });
            },
            child: const Text("Klik ", style: ukuran))
      ],
    );
  }
}
