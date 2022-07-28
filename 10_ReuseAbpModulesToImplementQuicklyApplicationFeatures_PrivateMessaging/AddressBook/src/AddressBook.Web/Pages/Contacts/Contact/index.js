$(function () {

    var l = abp.localization.getResource('AddressBook');

    var service = addressBook.contacts.contact;
    var createModal = new abp.ModalManager(abp.appPath + 'Contacts/Contact/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Contacts/Contact/EditModal');

    var dataTable = $('#ContactTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('AddressBook.Contact.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('AddressBook.Contact.Delete'),
                                confirmMessage: function (data) {
                                    return l('ContactDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('ContactName'),
                data: "name"
            },
            {
                title: l('ContactPhoneNumber'),
                data: "phoneNumber"
            },
            {
                title: l('ContactAddress'),
                data: "address"
            },
            {
                title: l('ContactAge'),
                data: "age"
            },
            {
                title: l('ContactBirthDay'),
                data: "birthDay"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewContactButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
